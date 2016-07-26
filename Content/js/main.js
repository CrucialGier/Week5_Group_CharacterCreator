$(function() {
    $("#class").change(function() {
      if ($(this).val() === "custom") {
        $(".extended-form").show();
      } else {
        $(".extended-form").hide();
      }
    });
});
