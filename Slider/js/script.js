var leftBtn=document.querySelector(".leftButton");
var rightBtn=document.querySelector(".rightButton");
var smallBtn1=document.querySelector(".btn1");
var smallBtn2=document.querySelector(".btn2");
var smallBtn3=document.querySelector(".btn3");
var smallBtn4=document.querySelector(".btn4");
var smallBtn5=document.querySelector(".btn5");
var mainImage=document.querySelector(".mainImage img");
var images=["images/landscape01.jpg", "images/landscape02.jpg", "images/landscape03.jpg", "images/landscape04.jpg", "images/landscape05.jpg"];
var check=2;

leftBtn.addEventListener("click", function() {
	check--;
	if (check<0)
	{
		check=images.length-1;
	}
	correctOpacity();
	mainImage.setAttribute("src", images[check]);
})

rightBtn.addEventListener("click", goRight)

setInterval(goRight, 5000);

function goRight() {
	check++;
	if (check==images.length)
	{
		check=0;
	}
	correctOpacity();
	mainImage.setAttribute("src", images[check]);
}

smallBtn1.addEventListener("click", function() {
	check=0;
	correctOpacity();
	mainImage.setAttribute("src", images[0]);
})

smallBtn2.addEventListener("click", function() {
	check=1;
	correctOpacity();
	mainImage.setAttribute("src", images[1]);
})

smallBtn3.addEventListener("click", function() {
	check=2;
	correctOpacity();
	mainImage.setAttribute("src", images[2]);
})

smallBtn4.addEventListener("click", function() {
	check=3;
	correctOpacity();
	mainImage.setAttribute("src", images[3]);
})

smallBtn5.addEventListener("click", function() {
	check=4;
	correctOpacity();
	mainImage.setAttribute("src", images[4]);
})

function correctOpacity() {
	switch (check) {
		case 0:
			smallBtn1.style.opacity=0.9;
			smallBtn2.style.opacity=0.4;
			smallBtn3.style.opacity=0.4;
			smallBtn4.style.opacity=0.4;
			smallBtn5.style.opacity=0.4;
			break;
		case 1:
			smallBtn1.style.opacity=0.4;
			smallBtn2.style.opacity=0.9;
			smallBtn3.style.opacity=0.4;
			smallBtn4.style.opacity=0.4;
			smallBtn5.style.opacity=0.4;
			break;
		case 2:
			smallBtn1.style.opacity=0.4;
			smallBtn2.style.opacity=0.4;
			smallBtn3.style.opacity=0.9;
			smallBtn4.style.opacity=0.4;
			smallBtn5.style.opacity=0.4;
		break;
		case 3:
			smallBtn1.style.opacity=0.4;
			smallBtn2.style.opacity=0.4;
			smallBtn3.style.opacity=0.4;
			smallBtn4.style.opacity=0.9;
			smallBtn5.style.opacity=0.4;
		break;
		case 4:
			smallBtn1.style.opacity=0.4;
			smallBtn2.style.opacity=0.4;
			smallBtn3.style.opacity=0.4;
			smallBtn4.style.opacity=0.4;
			smallBtn5.style.opacity=0.9;
		break;
	}
}