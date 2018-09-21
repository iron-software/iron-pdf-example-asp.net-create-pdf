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
Imports System.Web.Routing

Namespace DemoWebSite
	Public Class MvcApplication
		Inherits System.Web.HttpApplication

		Protected Sub Application_Start()
			AreaRegistration.RegisterAllAreas()
			RouteConfig.RegisterRoutes(RouteTable.Routes)
		End Sub
	End Class
End Namespace
