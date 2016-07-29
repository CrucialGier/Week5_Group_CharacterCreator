function Cube(id, size, left, top) {
  this.id = id;
  this.size = size;
  this.left = left;
  this.top = top;
  this.z = Math.random() * -400;
  this.html = `
  <div class="cube-wrap" id="` + this.id + `">
    <div class="shape cube">
      <div class="back face">
      </div>
      <div class="right face">
      </div>
      <div class="left face">
      </div>
      <div class="top face">
      </div>
      <div class="bottom face">
      </div>
      <div class="front face">
      </div>
    </div>
  </div>`
  this.css = {
    main: {
      'height': this.size,
      'width': this.size,
      'top': this.top,
      'left': this.left
    },
    back: {
      'transform': 'rotateY(180deg) translateZ(' + parseFloat(this.size) / 2 + 'px)'
    },
    right: {
      'transform': 'rotateY(-270deg) translateZ(' + parseFloat(this.size) / 2 + 'px)'
    },
    left: {
      'transform': 'rotateY(270deg) translateZ(' + parseFloat(this.size) / 2 + 'px)'
    },
    top: {
      'transform': 'rotateX(90deg) translateZ(' + parseFloat(this.size) / 2 + 'px)'
    },
    bottom: {
      'transform': 'rotateX(-90deg) translateZ(' + parseFloat(this.size) / 2 + 'px)'
    },
    front: {
      'transform': 'translateZ(' + parseFloat(this.size) / 2 + 'px)'
    }
  }
}
var cubes = [];
$(function() {
  // $('input[data-name="Business body"], input[data-name="Business Outfit"], input[data-name="Golf club"], input[data-name="Brief Case"]').prop('checked', true);
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


  for (var i = 0; i < 150; i++) {
    var cube = new Cube("cube-" + i, Math.random() * 20 + 30 + 'px', Math.random() * 200 - 50 + 'vw', Math.random() * 200 - 50 + '100vh');
    cubes.push(cube)
    $(".background").append(cube.html);
    $("#cube-" + i).css(cube.css.main);
    $("#cube-" + i + " .back").css(cube.css.back);
    $("#cube-" + i + " .right").css(cube.css.right);
    $("#cube-" + i + " .left").css(cube.css.left);
    $("#cube-" + i + " .top").css(cube.css.top);
    $("#cube-" + i + " .bottom").css(cube.css.bottom);
    $("#cube-" + i + " .front").css(cube.css.front);
      $("#" + cube.id).css('transform', 'translateZ(' + cube.z + 'px)');
  }
  $("body").mousemove(function (event) {
    var offsetX = 100 / $(window).width() * event.pageX - 50;
    var offsetY = 100 / $(window).height() * event.pageY - 50;
    cubes.forEach(function (cube) {
      $("#" + cube.id).css('transform', 'translateX(' + offsetX / -12 + 'vw) translateY(' + offsetY / -12 + 'vh) translateZ(' + cube.z + 'px)');
    })
  })

});
