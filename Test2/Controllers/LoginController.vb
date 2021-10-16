Imports System.IdentityModel.Tokens.Jwt
Imports System.Net
Imports System.Security.Claims
Imports System.Web.Http
Imports Microsoft.IdentityModel.Tokens
Imports Newtonsoft.Json

Namespace Controllers
    Public Class LoginController
        Inherits ApiController

        <HttpPost>
        <AllowAnonymous>
        Function Login(<FromBody()> ByVal loginData As UserLogin)
            If String.IsNullOrEmpty(loginData.username) Or String.IsNullOrEmpty(loginData.password) Then
                Return BadRequest("username and password must be provided")
            End If

            If AuthenticateUser(loginData) Then
                Return Ok(New With {
                    .token = generateJWT(loginData)
                })
            Else
                Return Unauthorized()
            End If

        End Function

        Private Function AuthenticateUser(ByRef userLogin As UserLogin) As Boolean
            If userLogin.username = "usr" And userLogin.password = "pass" Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function generateJWT(ByRef loginData As UserLogin) As String
            Dim secret As String = ConfigurationManager.AppSettings("JWT_Secret")
            Dim issuer As String = ConfigurationManager.AppSettings("JWT_Issuer")
            Dim audience As String = ConfigurationManager.AppSettings("JWT_Audience")
            Dim expiry As Integer = Convert.ToInt32(ConfigurationManager.AppSettings("JWT_Expires"))

            Dim key As SymmetricSecurityKey = New SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
            Dim signCreds As SigningCredentials = New SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            Dim header As JwtHeader = New JwtHeader(signCreds)

            Dim claims = New Claim() {
                New Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                New Claim(JwtRegisteredClaimNames.NameId, loginData.username)
            }

            Dim payload As JwtPayload = New JwtPayload(issuer,
                                                       audience,
                                                       claims,
                                                       DateTime.UtcNow,
                                                       DateTime.UtcNow.AddHours(expiry)
                                                      )

            Dim token = New JwtSecurityToken(header, payload)
            Return New JwtSecurityTokenHandler().WriteToken(token)
        End Function
    End Class
End Namespace