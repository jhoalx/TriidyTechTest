Imports System.Net.Http
Imports Newtonsoft.Json

Public Class frmMain
    Private ReadOnly client As HttpClient

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        client = New HttpClient With {
            .BaseAddress = New Uri("http://3.128.143.29/")
        }
    End Sub

    Function ExtractValueFromResult(ByRef text As String)
        Dim LastSpacePos As Int32 = text.LastIndexOf(" ")
        Dim LastQuotesPos As Int32 = text.LastIndexOf(ControlChars.Quote)

        Return text.Substring(LastSpacePos + 1, (text.Length - LastSpacePos) - (text.Length - LastQuotesPos + 1))
    End Function

    Private Async Sub btnQueryService_Click(sender As Object, e As EventArgs) Handles btnQueryService.Click
        If String.IsNullOrEmpty(txtProductId.Text) Then
            MessageBox.Show("Please type a product id to query", "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            Dim requestData As New RequestData With {
                .token = "12fr45ññtñue2y3pw57",
                .id_producto = txtProductId.Text
            }

            Dim requestContent As New StringContent(JsonConvert.SerializeObject(requestData), System.Text.Encoding.UTF8, "application/json")

            Dim Response As HttpResponseMessage = Await client.PostAsync("/rest/api/workshop", requestContent)
            Dim resultString As String = Await Response.Content.ReadAsStringAsync()

            lblResult.Text = ExtractValueFromResult(resultString)
        Catch ex As HttpRequestException
            MessageBox.Show("Error: " + ex.Message, "Http Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
