Module fcaStructures

    'Enumerates the distance-decay types available
    Public Enum decayType
        Classic
        Linear
    End Enum

    'Stores a layer name and its corresponding map index position
    Public Structure layerItem
        Public title As String
        Public position As Integer
    End Structure

    'Facilitates the tallying up of results during Step 2 of the FCA analysis
    Public Class destObj
        Public count As Double = 0.0
        Public sumdist As Double = 0.0
        Public twostep As Double = 0.0
    End Class

End Module
