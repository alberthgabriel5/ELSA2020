
    $(function () {
        $(".date").datepicker({
            startDate: new Date(),
            changeMonth: true,
            changeYear: true,
            format: "yyyy-mm-dd",
            language: "tr",
        });

        $(".date").datepicker({
            changeMonth: true,
            changeYear: true,
            format: "yyyy-mm-dd",
            language: "tr"
        });
});