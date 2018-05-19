Imports System.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.DashboardWin
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.ViewerData

Namespace Dashboard_ElementCustomColor
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            dashboardViewer1.LoadDashboard("..\..\Data\Dashboard.xml")
        End Sub

        Private Sub dashboardViewer1_DashboardItemElementCustomColor(ByVal sender As Object, _
                                     ByVal e As DashboardItemElementCustomColorEventArgs) _
                                 Handles dashboardViewer1.DashboardItemElementCustomColor

            Dim data As MultiDimensionalData = e.Data
            Dim currentElement As AxisPointTuple = e.TargetElement

            If e.DashboardItemName = "chartDashboardItem1" Then
                Dim country As String = _
                    currentElement.GetAxisPoint(DashboardDataAxisNames.ChartSeriesAxis).Value.ToString()
                Dim value As Decimal = _
                    CDec((data.GetSlice(currentElement)).GetValue(e.Measures(0)).Value)
                If country = "UK" AndAlso value > 50000 OrElse country = "USA" AndAlso value > 100000 _
                    Then
                    e.Color = Color.DarkGreen
                Else
                    e.Color = Color.DarkRed
                End If
            End If
            If e.DashboardItemName = "pieDashboardItem1" Then
                Dim value As Decimal = _
                    CDec((data.GetSlice(currentElement)).GetValue(data.GetMeasures()(0)).Value)
                If value < 100000 Then
                    e.Color = Color.Orange
                End If
            End If
        End Sub
    End Class
End Namespace
