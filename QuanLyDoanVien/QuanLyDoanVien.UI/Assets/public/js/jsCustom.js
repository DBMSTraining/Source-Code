$(document).ready(function(){
	$("#btnmodel").click(function(){
		$(".cus-modal").css("display","block");
		var name = $("#f-name").text(); 
		var sex = $("#f-sex").text(); 
		var mail = $("#f-mail").text(); 
		var province = $("#f-provice").text();
		var chuyenmon = $("#f-chuyenmon").text();
		var hocvan = $("#f-hocvan").text();
		var jobs = $("#f-jobs").text();
		var languages = $("#f-languages").text();
		$("#name").val(name);
		if(sex=="Male"){
			// ('input:radio[name=gender]:nth(0)').attr('checked',true);
			$('input:radio[name=gender]')[0].checked = true;
			// $('input:radio[name=gender]')[1].checked = false;
		}
		else{
			// ('input:radio[name=gender]:nth(1)').attr('checked',true);
			$('input:radio[name=gender]')[1].checked = true;
			// $('input:radio[name=gender]')[0].checked = false;
		}
		// $("#sex").val(sex);
		$("#mail").val(mail);
		$("#address").val(province);
		$("#chuyenmon").val(chuyenmon);
		$("#hocvan").val(hocvan);
		$("#jobs").val(jobs);
		$("#languages").val(languages);
		
	});
	$("#changes").click(function(){
		var per=0;
		$(".cus-modal").css("display","none");
		var name = $("#name").val(); 
		var sex = $('[name="gender"]:radio:checked').val();
		console.log(sex);
		var mail = $("#mail").val(); 
		var province = $("#address").val();
		var chuyenmon = $("#chuyenmon").val();
		var hocvan = $("#hocvan").val();
		var jobs = $("#jobs").val();
		var languages = $("#languages").val();
	
		if(name==''||name=='None update(*)'){
			$("#f-name").text("Chưa cập nhật(*)");
			$("#f-name").css({"color":"red", "font-size":"85%"});
			
		}
		else{
			$("#f-name").css("color","black");
			$("#f-name").text(name);
			per++;
		}

		if(sex==''||sex=='None update(*)'){
			$("#f-sex").text("None update(*)");
			$("#f-sex").css({"color":"red", "font-size":"85%"});
			
		}
		else{$("#f-sex").text(sex);
			$("#f-sex").css("color","black");
			per++;
		}

		if(mail==''||mail=='None update(*)'){
			$("#f-mail").text("None update(*)");
			$("#f-mail").css({"color":"red", "font-size":"85%"});
			
		}
		else{
			$("#f-mail").text(mail);
			$("#f-mail").css("color","black");
			per++;
		}

		if(province==''||province=='None update(*)'){
			$("#f-provice").text("None update(*)");
			$("#f-provice").css({"color":"red", "font-size":"85%"});
			
		}
		else{
			$("#f-provice").text(province);
			$("#f-provice").css("color","black");
			per++;
		}

		if(chuyenmon==''||chuyenmon=='None update(*)'){
			$("#f-chuyenmon").text("None update(*)");
			$("#f-chuyenmon").css({"color":"red", "font-size":"85%"});
			
		}
		else{
			$("#f-chuyenmon").text(chuyenmon);
			$("#f-chuyenmon").css("color","black");
			per++;
		}

		if(jobs==''||jobs=='None update(*)'){
			$("#f-jobs").text("None update(*)");
			$("#f-jobs").css({"color":"red", "font-size":"85%"});
			
		}
		else{
			$("#f-jobs").text(jobs);
			$("#f-jobs").css("color","black");
			per++;
		}
		if(languages==''||languages=='None update(*)'){
			$("#f-languages").text("None update(*)");
			$("#f-languages").css({"color":"red", "font-size":"85%"});
			
		}
		else{
				$("#f-languages").text(languages);
			$("#f-languages").css("color","black");
			per++;
		}
		if(hocvan==''||hocvan=='None update(*)'){
			$("#f-hocvan").text("None update(*)");
			$("#f-hocvan").css({"color":"red", "font-size":"85%"});
		
		}
		else{
				$("#f-hocvan").text(languages);
			$("#f-hocvan").css("color","black");
				per++;
		}
		var s = per*100/8;
		$("#probarr .progress-bar").css("width",s+"%");
		$("#probarr .progress-bar").html(s+"%");
		$("#perprog").text(s+"%");
	});
	$(".cus-close").click(function(){
		$(".cus-modal").css("display","none");
	});
});

// $(document).ready(function () {
	
//     $('.nav-tabs > li a[title]').tooltip();
    
//     $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

//         var $target = $(e.target);
    
//         if ($target.parent().hasClass('disabled')) {
//             return false;
//         }
//     });

//     $(".next-step").click(function (e) {

//         var $active = $('.wizard .nav-tabs li.active');
//         $active.next().removeClass('disabled');
//         nextTab($active);

//     });
//     $(".prev-step").click(function (e) {

//         var $active = $('.wizard .nav-tabs li.active');
//         prevTab($active);

//     });
// });

// function nextTab(elem) {
//     $(elem).next().find('a[data-toggle="tab"]').click();
// }
// function prevTab(elem) {
//     $(elem).prev().find('a[data-toggle="tab"]').click();
// }
$(document).ready(function(){
	$("#file").on("change",function(e){
		var files=$(this)[0].files;
		if(files.length>=2){
			$(".label-span").text(files.length +" file ready to upload");
		}
		else if(files.lenth==0){

		}else
			{
				var filename=e.target.value.split('\\').pop();
				$(".label-span").text(filename);
				
			}

	})
})

$(document).ready(function(){
	$("#sub-1").click(function(){
		$(".active-sub").removeClass();
		$("#sub-1").addClass("active-sub");
	})
	$("#sub-2").click(function(){
		$(".active-sub").removeClass();
		$("#sub-2").addClass("active-sub");
	})
	$("#sub-3").click(function(){
		$(".active-sub").removeClass();
		$("#sub-3").addClass("active-sub");
	})
	$("#sub-4").click(function(){
		$(".active-sub").removeClass();
	});
});



$(document).ready(function(){

	$("#numberchapter").focusout(function(){
		var s = $("#numberchapter").val();
		if(s==''){
			$("#number-chapter span.invalid").css("display","inline-block");
			$("#number-chapter span.valid").css("display","none");
		}
		else{
			$("#number-chapter span.invalid").css("display","none");
			$("#number-chapter span.valid").css("display","inline-block");

		}
	});

	$("#namepost").focusout(function(){
		var s = $("#namepost").val();
		if(s==''){
			$("#name-post span.invalid").css("display","inline-block");
			$("#name-post span.valid").css("display","none");

		}
		else{
			$("#name-post span.invalid").css("display","none");
			$("#name-post span.valid").css("display","inline-block");

		}
	});

	$("#summary").focusout(function(){
		var s = $("#summary").val();
		if(s==''){
			$("#-summary span.invalid").css("display","inline-block");
			$("#-summary span.valid").css("display","none");

		}
		else{
			$("#-summary span.invalid").css("display","none");
			$("#-summary span.valid").css("display","inline-block");

		}
	});

});



//form winrar custom
$("ul.j-index li:first").addClass("active").show();
$(document).ready(function(){
	$("ul.j-index li").click(function(){
		var a=$("ul.j-index li").index(this);
		$("#ff-step").removeClass();
		$("#ff-step").addClass("ff-active-"+a);
		$("ul.j-index li").removeClass("active");
		$(this).addClass("active");
		switch(a){
			case 0:
				$("#step1").show();
				$("#step2").hide();
				$("#step3").hide();
				break;
			case 1:
				$("#step2").show();
				$("#step1").hide();
				$("#step3").hide();
				break;
			case 2:
				$("#step1").hide();
				$("#step2").hide();
				$("#step3").show();
				break;
			default:
				break; 
		}
	});
	$("#steptopic").click(function(){
		$("#ff-step").removeClass();
		$("#ff-step").addClass("ff-active-1");
		$("ul.j-index li").removeClass("active");
		$("ul.j-index li:nth-child(2)").addClass("active");

		$("#step2").show();
		$("#step1").hide();
		$("#step3").hide();
	});
	$("#stepsubmit").click(function(){
		$("#ff-step").removeClass();
		$("#ff-step").addClass("ff-active-2");
		$("ul.j-index li").removeClass("active");
		$("ul.j-index li:nth-child(3)").addClass("active");

		$("#step2").hide();
		$("#step1").hide();
		$("#step3").show();
	});
	$("#prevsubmit").click(function(){
		$("#ff-step").removeClass();
		$("#ff-step").addClass("ff-active-2");
		$("ul.j-index li").removeClass("active");
		$("ul.j-index li:nth-child(3)").addClass("active");

		$("#step2").show();
		$("#step1").hide();
		$("#step3").hide();
	});
	$("#prevtopic").click(function(){
		$("#ff-step").removeClass();
		$("#ff-step").addClass("ff-active-2");
		$("ul.j-index li").removeClass("active");
		$("ul.j-index li:nth-child(3)").addClass("active");

		$("#step2").hide();
		$("#step1").show();
		$("#step3").hide();
	});
});

$(document).ready(function(){
	$("#modifypass").click(function(){
		$("input[name='Password']").prop('disabled', false);
		$("#confirmpass").show();
	})
	$("#modifyemail").click(function(){
		$("input[name='email']").prop('disabled', false);
	})
	$("#modifyphone").click(function(){
		$("input[name='Phone']").prop('disabled', false);
	})
})


$(document).ready(function(){
	$("#mananew1, #mananew2, #mananew3").click(function(){
		window.location.href="managernewsevent.html";
	})
	$("#manauser1, #manauser2, #manauser3").click(function(){
		window.location.href="manageruser.html";
	})
	$("#manatopic1, #manatopic2, #manatopic3").click(function(){
		window.location.href="topicmanagement.html";
	})
});
