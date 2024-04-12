import { defineConfig } from 'vite'
import fable from "vite-plugin-fable"

// https://vitejs.dev/config/
export default defineConfig({
    clearScreen: false,
    plugins: [ fable() ]
})