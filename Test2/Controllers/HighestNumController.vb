Imports System.Net
Imports System.Web.Http
Imports Newtonsoft.Json

Namespace Controllers
    Public Class HighestNumController
        Inherits ApiController

        ' POST: api/HighestNum
        <HttpPost>
        Function GetHighestNum(<FromBody()> ByVal value As Object)
            Dim requestData As GreatherThan = JsonConvert.DeserializeObject(Of GreatherThan)(value.ToString())
            Return Ok(requestData.getHighestNumber())
        End Function

    End Class
End Namespace