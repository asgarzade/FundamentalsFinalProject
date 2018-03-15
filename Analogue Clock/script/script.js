var secondElem=document.querySelector(".second");
var minuteElem=document.querySelector(".minute");
var hourElem=document.querySelector(".hour");
var d = new Date();
var second=d.getSeconds();
var secondAngle=roundToSix(second);
var minute=d.getMinutes();
var minuteAngle=minute*6;
var hour=d.getHours();
var hourAngle=(hour*30)+(minuteAngle/12);

function roundToSix(number)
{
	while (number%6!=0)
	{
		number++;
	}
	return number;
}

function rotate()
{
	console.log(secondAngle);
	secondAngle+=6;
	if(secondAngle>355)
	{
		secondAngle=0;
		minuteAngle+=6;
		hourAngle+=0.5;
		if(minuteAngle>355)
		{
			minuteAngle=0;			
		}
		if(hourAngle>719.5)
		{
			hourAngle=0;
		}
		hourElem.style.transform="rotate("+hourAngle+"deg)";
		minuteElem.style.transform="rotate("+minuteAngle+"deg)";
	}
	secondElem.style.transform="rotate("+secondAngle+"deg)";
}

secondElem.style.transform="rotate("+secondAngle+"deg)";
minuteElem.style.transform="rotate("+minuteAngle+"deg)";
hourElem.style.transform="rotate("+hourAngle+"deg)";
setInterval(rotate, 1000);