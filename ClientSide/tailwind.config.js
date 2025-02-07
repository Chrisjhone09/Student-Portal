module.exports = {
    content: [
      './src/**/*.{html,ts}', // Add paths to your Angular components
    ],
    theme: {
        extend: {
            colors: {
                'primary' : 'blue'
            },
          screens: {
            'sm': '640px',  // Small screens
            'md': '768px',  // Medium screens
            'lg': '1024px', // Large screens
            'xl': '1280px', // Extra large screens
            '2xl': '1536px', // 2x large screens
          },
          
        },
    plugins: [],
  }
}