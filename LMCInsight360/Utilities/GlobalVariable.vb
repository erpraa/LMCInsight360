Module GlobalVariable
    Public AppSecurity As String = "R@z4ña"
    Public SystemTitle As String = "LMC Insight360"



    'Global String

    Public GstrUseID As String = Nothing
    Public GstrUselogin As String = Nothing
    Public GstrUsername As String = Nothing
    Public GstrPassword As String = Nothing
    Public GstrIsActive As String = Nothing
    Public GstrIsLoggedIn As String = Nothing
    Public GstrIsResetPass As String = Nothing


    'Report Excel Format
    Public Const NumericFormat As String = "#,##0.00;(#,##0.00)"
    Public Const CurrencyFormat As String = "_(₱* #,##0.00_);_(₱* (#,##0.00);_(₱* " & Chr(34) & " - " & Chr(34) & "??_);_(@_)"
    Public Const PercentageFormat As String = "00.00%"

    Public Const DSNumericFormat As String = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

    Public Const ExchangeRateFormat As String = "_(* #,##0.0000_);_(* (#,##0.0000);_(* "" - ""??_);_(@_)"
    Public Const DollarFormat As String = "\$#,##0.00"

    Public Gbl_ReportTag As Integer = Nothing

End Module
