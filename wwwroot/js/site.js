// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var oldAlertId = alertId;

var alertDto = {
    AlertId: 0,                // force create
    OldAlertId: oldAlertId,    // remember the old one
    AlertDescription: alertDescription,
    IsActive: alertIsActive,
    AlertTypeId: Number(alertTypeId)
};
