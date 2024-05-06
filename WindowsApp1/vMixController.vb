Imports System.Net.Http
Imports System.Threading.Tasks

Public Class form1

    Private ReadOnly _vmixApiEndpoint As String = "http://localhost:8088/api"

    ' Function to switch to a specific input
    Public Async Function SwitchToInputAsync(inputNumber As Integer) As Task
        Using httpClient As New HttpClient()
            ' Create the request URL
            Dim requestUrl As String = $"{_vmixApiEndpoint}?Function=PreviewInput&Input={inputNumber}"

            ' Send the GET request
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(requestUrl)

            ' Check the response
            If Not response.IsSuccessStatusCode Then
                Throw New Exception("Failed to send command to vMix.")
            End If
        End Using
    End Function
    Public Async Function ShowGraphicsTemplateAsync(inputNumber As Integer, overlayIndex As Integer) As Task
        Using httpClient As New HttpClient()
            ' Show the template using Overlay1
            Dim requestUrl As String = $"{_vmixApiEndpoint}?Function=OverlayInput{overlayIndex}&Input={inputNumber}"
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(requestUrl)

            If Not response.IsSuccessStatusCode Then
                Throw New Exception("Failed to show graphics template.")
            End If
        End Using
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim unused = SwitchToInputAsync(1)
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim unused = ShowGraphicsTemplateAsync(1, 1)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim unused = SwitchToInputAsync(2)

    End Sub
    Public Async Function UpdateGraphicsTextAsync(inputNumber As Integer, fieldName As String, newValue As String) As Task
        Using httpClient As New HttpClient()
            ' Create the request URL for setting text
            Dim requestUrl As String = $"{_vmixApiEndpoint}?Function=SetText&Input={inputNumber}&SelectedName={fieldName}&Value={newValue}"

            ' Send the GET request to update the text
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(requestUrl)

            If Not response.IsSuccessStatusCode Then
                Throw New Exception("Failed to update graphics data.")
            End If
        End Using
    End Function
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ' Update "Line1" field in Input 1 with a new value
        Dim unused = UpdateGraphicsTextAsync(1, "Headline", TextBox1.Text)
        Dim unused2 = UpdateGraphicsTextAsync(1, "Description", TextBox2.Text)

    End Sub
End Class
