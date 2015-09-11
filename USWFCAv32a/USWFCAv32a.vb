Public Class USWFCAv32a
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    'Create an object to store all the analysis parameters
    Public configObj As New configParams

    Protected Overrides Sub OnClick()

        'Display Input Form 1, passing through the configObj
        Dim p_s1frmNetworkLayers As New s1_frmIntroduction(configObj)
        p_s1frmNetworkLayers.Show()

    End Sub

End Class
