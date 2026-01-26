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
                "Bug fixes in Data initialization"
            },
            .ReleaseDate = #12/23/2025#
        },
        New UpdateInfo With {
            .Version = "1.0.0.3",
            .Descriptions = New List(Of String) From {
                "Updated the database connection settings in the Login Module",
                "Implemented a new feature for encoding purchase transactions",
                "The Consolidated Annex B button is now functioning properly",
                "Fixed the Amount polarity in the Detail Schedule Report in Annex A"
            },
            .ReleaseDate = #01/16/2026#
        },
                New UpdateInfo With {
            .Version = "1.0.0.4",
            .Descriptions = New List(Of String) From {
                "Minor update in Annex B - Unrealize peso amount",
                "Fixed GUI auto scaling according to user settings",
                "Implemented a new feature for Reset Password",
                "Apply data loading lock to prevent other users from loading data"
            },
            .ReleaseDate = #01/22/2026#
         },
                New UpdateInfo With {
            .Version = "1.0.0.5",
            .Descriptions = New List(Of String) From {
                "Implemented a new feature Annex C",
                 "Cost of Sales Ratio Report"
            },
            .ReleaseDate = #01/26/2026#
        }
    }

End Module
