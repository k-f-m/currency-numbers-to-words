const PROXY_CONFIG = [
  {
    context: [
      "/api/Conversion",
    ],
    target: "https://localhost:7269",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
