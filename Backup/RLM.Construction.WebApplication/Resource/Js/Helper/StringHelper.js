function StringHelper() { };
StringHelper = {
    isNullOrEmpty: function (value) {
        return !value || value == '';
    },
    trim: function (str, maxLength) {
        try {
            if (!str || str.length <= maxLength) { return str; }
            var index = str.indexOf(' ', maxLength);
            if (index == -1) { return str; }
            return str.substring(0, index) + ' ...';
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    }
};