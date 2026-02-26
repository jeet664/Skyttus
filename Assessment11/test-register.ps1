$body = @{
    email = "newuser@test.com"
    password = "NewUser@123"
    firstName = "New"
    lastName = "User"
} | ConvertTo-Json

$response = Invoke-WebRequest -Uri "http://localhost:5192/api/auth/register" -Method POST -Body $body -ContentType "application/json" -UseBasicParsing
Write-Host "Status Code:" $response.StatusCode
Write-Host "Response:" $response.Content
