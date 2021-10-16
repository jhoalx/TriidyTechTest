Imports System.Net
Imports System.Web.Http
Imports Newtonsoft.Json

Namespace Controllers
    Public Class HighestNumController
        Inherits ApiController

        ' POST: api/HighestNum
        <Authorize>
        <HttpPost>
        Function GetHighestNum(<FromBody()> ByVal requestData As GreatherThan)
            Return Ok(requestData.getHighestNumber())
        End Function

    End Class
End Namespace