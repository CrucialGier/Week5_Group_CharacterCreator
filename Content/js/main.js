$(function() {
    $("input[type='radio']:checked").each(function(){
      console.log($(this).attr("data-image"));
      var src = "../../Content/img/" + $(this).attr("data-image");
      var name = $(this).attr("data-name");
      var type = $(this).attr("name");
      $("." + type).attr("src", src);
      $("." + type).attr("data-name", name);
    })
    $("#class").change(function() {
      if ($(this).val() === "custom") {
        $(".extended-form").show();
      } else {
        $(".extended-form").hide();
      }
    });

    $("input[type='radio']").change(function(){
      var src = "../../Content/img/" + $(this).attr("data-image");
      var name = $(this).attr("data-name");
      var type = $(this).attr("name");
      $("." + type).attr("src", src);
      $("." + type).attr("data-name", name);
    });

});
