'========================================================================
' This conversion was produced by the Free Edition of
' Instant VB courtesy of Tangible Software Solutions.
' Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
'========================================================================

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DemoWebSite.Filters

Namespace DemoWebSite.Controllers
	Public Class InvoiceController
		Inherits Controller

		' GET: Invoice
		<BasicAuthenticationFilter("testUser", "testPassword")>
		Public Function Index() As ActionResult
			Return View()
		End Function
	End Class
End Namespace