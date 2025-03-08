import { Faculty } from "./faculty";

export class FacultyListAndCountDTO {
    faculties : Faculty[] = []
    userCount : number = 0;
    studentCount : number = 0
    facultyCount: number = 0
    departmentCount: number = 0
}
