function PopupHelper() { }
PopupHelper = {
    onPartnerSelected: function(partnerId, name, contactName) {
        try {
            if (window.parent) {
                window.parent.onPartnerSelected(partnerId, name, contactName);
                window.parent.tb_remove();
            }
            
        } catch (e) {
            UtilityHelper.errorProcess(e);
        }
    }
};