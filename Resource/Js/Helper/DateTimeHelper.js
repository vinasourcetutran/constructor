function DateTimeHelper() { };
DateTimeHelper = {
    getNumberOfDays: function (fromcalendarId, tocalendarId) {
        var fromcalendar = $find(fromcalendarId);
        var tocalendar = $find(tocalendarId);
        if (!fromcalendar || !tocalendar) { return; }
        var numberOfMilisecond = tocalendar.get_selectedDate() - fromcalendar.get_selectedDate();
        return numberOfMilisecond / 86400000;
    },
    addDays: function (fromcalendarId, tocalendarId, days) {
        var fromcalendar = $find(fromcalendarId);
        var tocalendar = $find(tocalendarId);
        if (!fromcalendar || !tocalendar) { return; }
        if (days == 0 || days == "0" || !fromcalendar.get_selectedDate()) {
            tocalendar.set_selectedDate(fromcalendar.get_selectedDate());
        }
        var radDate = fromcalendar.get_selectedDate();
        //var date = new Date(radDate[0], radDate[1], radDate[2], 0, 0, 0, 0);

        //var milisecond = radDate.getMilliseconds() + days * 86400000;
        radDate.setDate(radDate.getDate() + days);
        //var todayTriplet = [date.getFullYear(), date.getMonth() + 1, date.getDate()];
        tocalendar.set_selectedDate(radDate); //[todayTriplet], true);
    }
};