Imports Microsoft.VisualBasic
Imports DevExpress.XtraMap
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace CustomRouteProvider
	Partial Public Class Form1
		Inherits Form
		Private ReadOnly Property Layer() As InformationLayer
			Get
				Return CType(mapControl1.Layers(1), InformationLayer)
			End Get
		End Property
		Public Sub New()
			InitializeComponent()
			Dim provider As New RouteProvider()
			Layer.DataProvider = provider
			provider.CalculateRoute(New GeoPoint(70, 60), New GeoPoint(-60, -70))
		End Sub
	End Class
	Public Class RouteProvider
		Inherits InformationDataProviderBase
		Protected Shadows ReadOnly Property Data() As RouteData
			Get
				Return CType(MyBase.Data, RouteData)
			End Get
		End Property
		Public ReadOnly Property Route() As IEnumerable(Of GeoPoint)
			Get
				Return Data.Route
			End Get
		End Property

		Protected Overrides Function CreateData() As IInformationData
			Return New RouteData()
		End Function
		Public Sub CalculateRoute(ByVal point1 As GeoPoint, ByVal point2 As GeoPoint)
			Data.CalculateRoute(point1, point2)
		End Sub
	End Class
	Public Class RouteData
		Implements IInformationData
		Private ReadOnly route_Renamed As New List(Of GeoPoint)()
		Public ReadOnly Property Route() As List(Of GeoPoint)
			Get
				Return route_Renamed
			End Get
		End Property
		Public Event OnDataResponse As EventHandler(Of RequestCompletedEventArgs) Implements IInformationData.OnDataResponse

        Private Function CreateEventArgs() As RequestCompletedEventArgs
			Dim items(2) As MapItem
			items(1) = New MapCallout() With {.Location = route_Renamed(0), .Text = route_Renamed(0).ToString()}
			items(2) = New MapCallout() With {.Location = route_Renamed(route_Renamed.Count - 1), .Text = route_Renamed(route_Renamed.Count - 1).ToString()}
			Dim polyline As New MapPolyline() With {.IsGeodesic = True, .Stroke = System.Drawing.Color.Red, .StrokeWidth = 4}
			Dim i As Integer = 0
			Do While i < route_Renamed.Count
				polyline.Points.Add(route_Renamed(i))
				i += 1
			Loop
			items(0) = polyline
			Return New RequestCompletedEventArgs(items, Nothing, False, Nothing)
		End Function
		Protected Sub RaiseChanged()
			RaiseEvent OnDataResponse(Me, CreateEventArgs())
		End Sub
		Public Sub CalculateRoute(ByVal point1 As GeoPoint, ByVal point2 As GeoPoint)
			CalculateRouteCore(point1, point2)
			RaiseChanged()
		End Sub
		Private Sub CalculateRouteCore(ByVal point1 As GeoPoint, ByVal point2 As GeoPoint)
			Me.route_Renamed.Clear()
			route_Renamed.Add(point1)
			route_Renamed.Add(point2)
		End Sub
	End Class
End Namespace
