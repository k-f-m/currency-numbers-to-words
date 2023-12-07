# Currency to Words Converter
ASP.NET Core 8 + Angular 17 single-page application (SPA) using Material Design to convert dollar values into equivalent words.

Conversion takes place on the server with extensive multi-level input validation. Feedback is provided to the user for a wide range of input combinations, including data entry errors.

![image](https://github.com/k-f-m/currency-numbers-to-words/assets/55965735/38194050-0a42-4989-87f2-e5aea7849fdd)

### Limitations
- The maximum number of dollars is 999 999 999.
- The maximum number of cents is 99.
- The separator between dollars and cents is a ',' (comma).

## URLs
- Sinle-page application: https://localhost:4200
- Swagger UI: https://localhost:7269/swagger/index.html
- API endpoint: https://localhost:7269/api/Conversion


# Tools, frameworks, and dependencies
- Visual Studio 2022
- Angular 17.0.5
- Microsoft.AspNetCore.App (8.0.0)
- Microsoft.NETCore.App (8.0.0)
- Microsoft.AspNetCore.SpaProxy (8.0.0)
- Swashbuckle.AspNetCore (6.4.0)