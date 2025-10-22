Module GlobalVariable

    Public SystemTitle As String = "LMC Insight360"
    Public AppSecurity As String = "R@z4ña"

    Public Const NumericFormat As String = "#,##0.00;(#,##0.00)"
    Public Const CurrencyFormat As String = "_(₱* #,##0.00_);_(₱* (#,##0.00);_(₱* " & Chr(34) & " - " & Chr(34) & "??_);_(@_)"
    Public Const PercentageFormat As String = "00.00%"

    Public Const DSNumericFormat As String = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"


    Public Gbl_ReportTag As Integer = Nothing

End Module
