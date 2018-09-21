'========================================================================
' This conversion was produced by the Free Edition of
' Instant VB courtesy of Tangible Software Solutions.
' Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
'========================================================================

Imports System
Imports System.Web.Mvc

Namespace DemoWebSite.Filters
	Public Class BasicAuthenticationFilterAttribute
		Inherits ActionFilterAttribute

		Public Property BasicRealm() As String
		Protected Property Username() As String
		Protected Property Password() As String

		Public Sub New(ByVal username As String, ByVal password As String)
			Me.Username = username
			Me.Password = password
		End Sub

		Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
			Dim req = filterContext.HttpContext.Request
			Dim auth = req.Headers("Authorization")
			If Not String.IsNullOrEmpty(auth) Then
				Dim cred = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(":"c)
				Dim user = New With {
					Key .Name = cred(0),
					Key .Pass = cred(1)
				}
				If user.Name = Username AndAlso user.Pass = Password Then
					Return
				End If
			End If
			Dim res = filterContext.HttpContext.Response
			res.StatusCode = 401
			res.AddHeader("WWW-Authenticate", String.Format("Basic realm=""{0}""", If(BasicRealm, "TestRealm")))
			res.End()
		End Sub
	End Class
End Namespace