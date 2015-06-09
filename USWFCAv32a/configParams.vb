Public Class configParams

    Private m_NWlayerindex As Integer = -1
    Private m_NWimpedanceField As String = ""
    Private m_NWdefCutOff As Double = 0.0
    Private m_NWscale As Double = 1.0
    Private m_SupplyLayerIndex As Integer = -1
    Private m_SupplySelected As Boolean = False
    Private m_SupplyVolumeField As Integer = -1
    Private m_DemandLayerIndex As Integer = -1
    Private m_DemandSelected As Boolean = False
    Private m_DemandVolumeField As Integer = -1
    Private m_ResultsLoc As String = ""
    Private m_filter As decayType = decayType.Classic
    Private m_gauss As Double = 0.0
    Private m_bwpass As Double = 0.0
    Private m_bwpower As Double = 0.0

    Public Sub New()
        MyBase.New()
    End Sub

    Public Property NWlayerindex() As Integer
        Get
            Return m_NWlayerindex
        End Get
        Set(ByVal value As Integer)
            m_NWlayerindex = value
        End Set
    End Property

    Public Property NWimpedanceField() As String
        Get
            Return m_NWimpedanceField
        End Get
        Set(ByVal value As String)
            m_NWimpedanceField = value
        End Set
    End Property

    Public Property NWdefCutOff() As Double
        Get
            Return m_NWdefCutOff
        End Get
        Set(ByVal value As Double)
            m_NWdefCutOff = value
        End Set
    End Property

    Public Property NWscale() As Double
        Get
            Return m_NWscale
        End Get
        Set(ByVal value As Double)
            m_NWscale = value
        End Set
    End Property

    Public Property SupplyLayerIndex() As Integer
        Get
            Return m_SupplyLayerIndex
        End Get
        Set(ByVal value As Integer)
            m_SupplyLayerIndex = value
        End Set
    End Property

    Public Property SupplySelected() As Boolean
        Get
            Return m_SupplySelected
        End Get
        Set(ByVal value As Boolean)
            m_SupplySelected = value
        End Set
    End Property

    Public Property SupplyVolumeField() As Integer
        Get
            Return m_SupplyVolumeField
        End Get
        Set(ByVal value As Integer)
            m_SupplyVolumeField = value
        End Set
    End Property

    Public Property DemandLayerIndex() As Integer
        Get
            Return m_DemandLayerIndex
        End Get
        Set(ByVal value As Integer)
            m_DemandLayerIndex = value
        End Set
    End Property

    Public Property DemandSelected() As Boolean
        Get
            Return m_DemandSelected
        End Get
        Set(ByVal value As Boolean)
            m_DemandSelected = value
        End Set
    End Property

    Public Property DemandVolumeField() As Integer
        Get
            Return m_DemandVolumeField
        End Get
        Set(ByVal value As Integer)
            m_DemandVolumeField = value
        End Set
    End Property

    Public Property gaussian_bw As Double
        Get
            Return m_gauss
        End Get
        Set(ByVal value As Double)
            m_gauss = value
        End Set
    End Property

    Public Property butterworth_pwr As Double
        Get
            Return m_bwpower
        End Get
        Set(ByVal value As Double)
3:          m_bwpower = value
        End Set
    End Property

    Public Property butterworth_bw As Double
        Get
            Return m_bwpass
        End Get
        Set(ByVal value As Double)
            m_bwpass = value
        End Set
    End Property

    Public Property filter As Integer
        Get
            Return m_filter
        End Get
        Set(ByVal value As Integer)
            m_filter = value
        End Set
    End Property

    Public Property ResultsLocation As String
        Get
            Return m_ResultsLoc
        End Get
        Set(ByVal value As String)
            m_ResultsLoc = value
        End Set
    End Property

End Class
