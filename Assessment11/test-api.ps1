$body = @{
    email = "admin@test.com"
    password = "Admin@123"
} | ConvertTo-Json

$response = Invoke-WebRequest -Uri "http://localhost:5192/api/auth/login" -Method POST -Body $body -ContentType "application/json" -UseBasicParsing
Write-Host "Status Code:" $response.StatusCode
Write-Host "Response:" $response.Content
