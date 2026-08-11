# UserManagementAPI

Project developed for the API Development course, covering activities 1, 2, and 3

---

## 📌 1# Writing and Enhancing API Code

### Issues Identified
- **[Missing validation](ca://s?q=Add_model_validation_ASP.NET_Core)**: Users were added without checking required fields.  
- **[Missing search](ca://s?q=Handle_nonexistent_user_ASP.NET_Core)**: Errors occurred when retrieving non-existent users.  
- **[Unhandled exceptions](ca://s?q=Handle_exceptions_ASP.NET_Core)**: Occasional failures due to lack of global error handling.  
- In-memory persistence only: Data stored in a static list without a real database.  
- Generic error messages: Inconsistent responses made API consumption difficult.  
---

## 📌 2# Debugging API Code 

### 1. Data Validation
- Implemented `DataAnnotations` in the `User` model:  
  - `[Required]` for mandatory fields.  
  - `[EmailAddress]` to validate email format.  
  - `[StringLength]` to limit string size.  

### 2. Exception Handling
- Added `try-catch` blocks in all `UsersController` endpoints.  
- Created **ErrorController** to capture global exceptions via `app.UseExceptionHandler("/error")`.  

### 3. Logic Optimization
- Used `Any()` before `Max()` to avoid errors with empty lists.  
- Replaced `Where().FirstOrDefault()` with `FirstOrDefault()` to reduce unnecessary operations.  
- Standardized error messages (`BadRequest`, `NotFound`, `StatusCode(500)`).  

---

## 🚀 Tests Performed
- **[Invalid input](ca://s?q=Test_model_validation_ASP.NET_Core)**: POST with invalid email returns `400 Bad Request`.  
- **[Non-existent IDs](ca://s?q=Test_nonexistent_user_ASP.NET_Core)**: GET with invalid IDs returns `404 Not Found`.  

---

## 📌 3# Implementing and Managing Middleware

### Installed Packages
- **[Microsoft.AspNetCore.Authentication.JwtBearer](ca://s?q=Microsoft.AspNetCore.Authentication.JwtBearer)**  
- **[Microsoft.AspNetCore.OpenApi](ca://s?q=Microsoft.AspNetCore.OpenApi)**  
- **[Microsoft.IdentityModel.Tokens](ca://s?q=Microsoft.IdentityModel.Tokens)**  
- **[System.IdentityModel.Tokens.Jwt](ca://s?q=System.IdentityModel.Tokens.Jwt)**  
- **[Swashbuckle.AspNetCore](ca://s?q=Swashbuckle.AspNetCore)**  
- **[Microsoft.OpenApi](ca://s?q=Microsoft.OpenApi)** (2.2.0)  

### Swagger Configuration with JWT Bearer
- Defined security scheme.  
- Added **Authorize** button in the Swagger UI.  
- Enabled testing of protected endpoints using `Bearer <token>`.  

---

## ✅ Final Outcome
- API validated with proper error handling.  
- Optimized logic and standardized responses.  
- Swagger configured with JWT authentication, enabling secure testing directly in the interface.  
