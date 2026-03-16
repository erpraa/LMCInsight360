' **********************************************************************
' Project Name      : LMC Insight360 (FS/SR Automation System)
' Prepared By       : ERP Department
' Commencement Date : August 20, 2025
' Project Lead      : Dennis Becina
' Programmer        : Raymart Azaña
' Status            : In Progress
' **********************************************************************
Module AppUpdates

    Public ReadOnly Updates As New List(Of UpdateInfo) From {
        New UpdateInfo With {
            .Version = "1.0.0.1",
            .Descriptions = New List(Of String) From {"Initial release"},
            .ReleaseDate = #12/16/2025#
        },
        New UpdateInfo With {
            .Version = "1.0.0.2",
            .Descriptions = New List(Of String) From {
                "Improved data initialization stability and accuracy."
            },
            .ReleaseDate = #12/23/2025#
        },
        New UpdateInfo With {
            .Version = "1.0.0.3",
            .Descriptions = New List(Of String) From {
                "Updated login database settings",
                "Added a new feature for encoding purchase transactions",
                "Consolidated Annex B button is now working",
                "Fixed amount polarity in the Detail Schedule Report (Annex A)"
            },
            .ReleaseDate = #01/16/2026#
        },
                New UpdateInfo With {
            .Version = "1.0.0.4",
            .Descriptions = New List(Of String) From {
                "Minor update on Annex B unrealized peso amounts",
                "Fixed GUI auto-scaling to fit user settings",
                "Added a Reset Password feature",
                "Added a data-loading lock to prevent multi-user conflicts"
            },
            .ReleaseDate = #01/22/2026#
         },
                New UpdateInfo With {
            .Version = "1.0.0.5",
            .Descriptions = New List(Of String) From {
                "Implemented Annex C",
                 "Added Cost of Sales Ratio and Manufacturing Cost reports",
                 "Fixed IBU clearing logic in the Balance Sheet (Annex A)"
            },
            .ReleaseDate = #02/24/2026#
            },
                New UpdateInfo With {
            .Version = "1.0.0.6",
            .Descriptions = New List(Of String) From {
                "Added Manufacturing Overhead Report",
                "Consolidated Annex C button is now working"
            },
            .ReleaseDate = #02/27/2026#
            },
                New UpdateInfo With {
            .Version = "1.0.0.7",
            .Descriptions = New List(Of String) From {
                "Added a User Access feature"
            },
            .ReleaseDate = #03/16/2026#
        }
    }

End Module
