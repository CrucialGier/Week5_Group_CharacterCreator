$(function() {
    $("#class").change(function() {
      if ($(this).val() === "custom") {
        $(".extended-form").show();
      } else {
        $(".extended-form").hide();
      }
    });
    
    $("input[type='radio']").change(function(){
      console.log($(this).attr("name"));
      var src = "../Content/img/" + $(this).attr("data-image");
      var name = $(this).attr("data-name");
      $(".character .weapon").attr("src", src);
      $(".character .weapon").attr("data-name", name);
    })

});
