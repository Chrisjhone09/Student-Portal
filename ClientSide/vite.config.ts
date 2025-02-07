import { defineConfig } from "vite";

export default defineConfig({
  server: {
    host: "0.0.0.0", // Allow access from network devices
    port: 4200, // Set the port
    cors: true,
    strictPort: false, // Prevent port fallback
    allowedHosts: ['All']
  },
});
