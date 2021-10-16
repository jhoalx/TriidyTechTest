Imports System.Net
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Threading.Tasks
Imports Microsoft.IdentityModel.Tokens

Public Class TokenValidationHandler
    Inherits DelegatingHandler

    Private Shared Function TryRetrieveToken(ByVal request As HttpRequestMessage, <Out> ByRef token As String) As Boolean
        token = Nothing
        Dim authHeaders As IEnumerable(Of String)

        If Not request.Headers.TryGetValues("Authorization", authHeaders) OrElse authHeaders.Count() > 1 Then
            Return False
        End If

        Dim bearerToken = authHeaders.ElementAt(0)
        token = If(bearerToken.StartsWith("Bearer "), bearerToken.Substring(7), bearerToken)
        Return True
    End Function

    Public Function LifetimeValidator(notBefore As DateTime?, expires As DateTime?, securityToken As SecurityToken, validationParameters As TokenValidationParameters) As Boolean
        Dim valid = False

        If (expires.HasValue AndAlso DateTime.UtcNow < expires) AndAlso (notBefore.HasValue AndAlso DateTime.UtcNow > notBefore) Then
            valid = True
        End If

        Return valid
    End Function

    Protected Overrides Function SendAsync(ByVal request As HttpRequestMessage, ByVal cancellationToken As CancellationToken) As Task(Of HttpResponseMessage)
        Dim statusCode As HttpStatusCode
        Dim token As String
        If Not TryRetrieveToken(request, token) Then
            statusCode = HttpStatusCode.Unauthorized
            Return MyBase.SendAsync(request, cancellationToken)
        End If

        Try
            Dim secret = ConfigurationManager.AppSettings("JWT_Secret")
            Dim issuer = ConfigurationManager.AppSettings("JWT_Issuer")
            Dim audience = ConfigurationManager.AppSettings("JWT_Audience")

            Dim securityKey = New SymmetricSecurityKey(Encoding.Default.GetBytes(secret))
            Dim securityToken As SecurityToken
            Dim tokenHandler = New IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler
            Dim validationParameters As New TokenValidationParameters With {
                .ValidAudience = audience,
                .ValidIssuer = issuer,
                .ValidateLifetime = True,
                .ValidateIssuerSigningKey = True,
                .IssuerSigningKey = securityKey
            }

            Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParameters, securityToken)
            HttpContext.Current.User = tokenHandler.ValidateToken(token, validationParameters, securityToken)
            Return MyBase.SendAsync(request, cancellationToken)
        Catch ex As SecurityTokenValidationException
            statusCode = HttpStatusCode.Unauthorized
        Catch ex As Exception
            statusCode = HttpStatusCode.InternalServerError
        End Try

        Return Task.Factory.StartNew(Function() New HttpResponseMessage(statusCode))
    End Function

End Class
