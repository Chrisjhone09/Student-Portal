import { defineConfig } from "vite";

export default defineConfig({
  server: {
    host: "0.0.0.0", // Allow access from network devices
    port: 4200, // Set the port
    strictPort: true, // Prevent port fallback
    cors: true, // Enable Cross-Origin Resource Sharing
    hmr: {
      clientPort: 443, // Required for Cloudflare Tunnel
    },
  },
});
