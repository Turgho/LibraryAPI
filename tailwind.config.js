/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Pages/**/*.{cshtml,html}',
    './Views/**/*.{cshtml,html}',
    './wwwroot/js/**/*.js'
  ],
  theme: {
    extend: {
      colors: {
        primary: '#3e2b24',     // marrom escuro
        secondary: '#D7CCC8',   // bege claro
        accent: '#8D6E63',      // marrom médio
        paper: '#FAF9F6',       // fundo claro
        text: '#212121'         // quase preto
      },
      fontFamily: {
        serif: ['Georgia', 'serif'],
        body: ['"Open Sans"', 'sans-serif']
      }
    },
  },
  plugins: [],
  
}

