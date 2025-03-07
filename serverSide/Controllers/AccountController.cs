﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server;
using serverSide.Data;
using serverSide.Models;
using serverSide.DTO;

namespace serverSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CDKPortalContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly CDKDbContext _dbContext;

        public AccountController(IConfiguration configuration, CDKPortalContext context,
                                SignInManager<User> signInManager,
                                UserManager<User> userManager,
                                RoleManager<IdentityRole> roleManager,
                                CDKDbContext dbContext)
        {
            _configuration = configuration;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {

            if (!ModelState.IsValid || model == null)
                return BadRequest("Invalid login request.");

            var user = await _userManager.FindByEmailAsync(model.CDKemail);

            if (user == null)
                return Unauthorized("Invalid email or password.");

            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);
            if (!passwordCheck.Succeeded)
                return Unauthorized("Invalid email or password.");

            var secretKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(secretKey))
                return StatusCode(500, "JWT secret key is not configured.");
            var roles = await _userManager.GetRolesAsync(user);
            var roleOfUser = roles.FirstOrDefault();


            var token = JwtTokenGenerator.GenerateToken(user, roleOfUser, secretKey, 30);

            var student = new User
            {
                Firstname = user.Firstname,
                UserName = user.UserName,
                Middlename = user.Middlename,
                Lastname = user.Lastname,
                Token = token
            };

            return Ok(student);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] object empty)
        {
            try
            {
                if (empty != null)
                {
                    await _signInManager.SignOutAsync();
                    return Ok(new { message = "Logout successful" });
                }
                return Unauthorized(new { message = "Invalid request" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during logout: {ex.Message}");
                return StatusCode(500, new { error = "An error occurred during logout" });
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {



            var isStudentEnrolled = _dbContext.Students.Any(s => s.StudentId == model.StudentId);
            if (model == null)
                return BadRequest("Invalid user data.");


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (isStudentEnrolled)
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                    return Conflict("A user with the same email already exists.");


                var user = new User
                {
                    UserName = model.Email,
                    Firstname = model.FirstName,
                    Middlename = model.MiddleName,
                    Lastname = model.LastName,
                    Email = model.Email,
                    LockoutEnabled = false,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                await _roleManager.CreateAsync(new IdentityRole("Student"));
                await _userManager.AddToRoleAsync(user, _roleManager.Roles.FirstOrDefault(r => r.Name == "Student").Name);

                if (result.Succeeded)
                {
                    var portalId = user.Id;

                    var getExistingStudent = _dbContext.Students.FirstOrDefault(s => s.StudentId == model.StudentId);
                    if (getExistingStudent != null)
                    {
                        getExistingStudent.PortalId = portalId;

                        _dbContext.Students.Update(getExistingStudent);
                        await _dbContext.SaveChangesAsync();

                        return Ok(new { message = "Registration successful." });
                    }
                    else
                    {
                        return BadRequest(new { message = "Student record not found." });
                    }
                }

            }
            else if (!isStudentEnrolled && _dbContext.Faculty.Any(i => i.FacultyId.ToString() == model.StudentId))
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                    return Conflict("A user with the same email already exists.");

                var user = new User
                {
                    UserName = model.Email,
                    Firstname = model.FirstName,
                    Middlename = model.MiddleName,
                    Lastname = model.LastName,
                    Email = model.Email,
                    LockoutEnabled = false,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                await _roleManager.CreateAsync(new IdentityRole("Instructor"));
                await _userManager.AddToRoleAsync(user, _roleManager.Roles.FirstOrDefault(r => r.Name == "Instructor").Name);
                if (result.Succeeded)
                {
                    var portalId = user.Id;

                    var getExistingInstructor = _dbContext.Faculty.FirstOrDefault(s => s.FacultyId.ToString() == model.StudentId);
                    if (getExistingInstructor != null)
                    {
                        getExistingInstructor.PortalId = portalId;

                        _dbContext.Faculty.Update(getExistingInstructor);
                        await _dbContext.SaveChangesAsync();

                        return Ok(new { message = "Registration successful." });
                    }
                    else
                    {
                        return BadRequest(new { message = "Student record not found." });
                    }
                }
            }

            return BadRequest();
        }
        
    }
}
