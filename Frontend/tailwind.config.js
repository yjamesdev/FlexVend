/** @type {import('tailwindcss').Config} */
export default {
  content: ['./src/**/*.{js,jsx,ts,tsx}'],
  theme: {
      extend: {
        fontFamily: {
          sans: ['Roboto', 'sans-serif'],
        },
        colors: {
            primary: "hsl(210, 100%, 90%)",        // Azul pastel claro como color principal
            primaryHover: "hsl(210, 100%, 80%)",   // Color al hacer hover
            pale: "hsl(210, 100%, 96%)",           // Un tono más claro para el pale color
            white: "#ffffff",                      // Color blanco
            black: "#000000",                      // Color negro
            grayText: "#6B7280",                   // Texto en color gris
            bgColor: "hsl(210, 50%, 98%)",         // Color de fondo claro
            inputColor: "hsl(210, 20%, 95%)"       // Color para inputs
          },
    },
  },
  plugins: [],
}
