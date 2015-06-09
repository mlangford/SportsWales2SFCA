Module fcaStructures

    'Enumerates the distance-decay types used in Enhanced 2SFCA
    Public Enum decayType
        Classic
        Linear
        Gaussian
        Butterworth
    End Enum

    'Stores a layer name and corresponding index position
    Public Structure layerItem
        Public title As String
        Public position As Integer
    End Structure

    'Facilitates tallying of results in Step 2 of the FCA analysis
    Public Class destObj
        Public count As Double = 0.0
        Public sumdist As Double = 0.0
        Public twostep As Double = 0.0
    End Class

End Module
