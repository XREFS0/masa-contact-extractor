# Security Policy

## Reporting a Vulnerability

If you discover a security vulnerability within MASA Contact Extractor, please send an email to XREFS0. All security vulnerabilities will be promptly addressed.

Please include the following information in your report:

- Type of vulnerability
- Steps to reproduce
- Potential impact
- Suggested fix (if any)

## Security Considerations

This application performs web scraping and data extraction. Users should be aware of:

- **Legal compliance**: Ensure you comply with local laws and the terms of service of websites being queried
- **Data privacy**: Extracted data may contain personal information (emails, phone numbers). Handle in accordance with applicable data protection regulations (GDPR, CCPA, etc.)
- **Rate limiting**: The application includes proxy support to help manage request rates. Use responsibly
- **Network security**: All HTTP requests use TLS encryption. SSL3 has been disabled

## Best Practices

- Run the application with standard user privileges (not administrator)
- Use proxy servers to avoid rate limiting and IP blocking
- Do not use this tool for spam, harassment, or any illegal purpose
- Respect website Terms of Service and robots.txt directives
