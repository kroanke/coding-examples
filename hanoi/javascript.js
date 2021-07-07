var delay = 200; //in milliseconds

var drag=false;
var objDisk=null;
var x = 0;
var y = 0;
var offsetleft = 30;
var offsettop = 30;
var offsettower = 20;
var offsethoriz = 30;
var basetop = 0;
var diskheight = 0;
var midhoriztower = 0;
var indexTo=1;
var indexFr=1;
var movectr=0;
var gameOver=false;
var prevIndex=0;
var zindex = 0;
var currTower=1;
var prevTower=1;
var demo=false;
var arrFr = new Array(255);
var arrTo = new Array(255);
var idx = 0;
var pos = 0;
var t=null;
var stop=false;
var disk1 = new Array(null,null,null,null,null,null,null,null);
var disk2 = new Array(null,null,null,null,null,null,null,null);
var disk3 = new Array(null,null,null,null,null,null,null,null);
var diskArray = new Array(disk1,disk2,disk3);


function init(){
if (document.getElementById){
var diskno = document.hanoi.diskno;
diskno.options.selectedIndex = 0;
drawTowers();
drawDisks(parseInt(diskno.options[diskno.options.selectedIndex].text));
}
}

function initVars(){
for (var i=0;i<disk1.length;i++){
disk1[i]=null;
disk2[i]=null;
disk3[i]=null;
}
drag = false;
indexTo = 1;
indexFr = 1;
movectr = 0;
zindex = 0;
idx = 0;
pos = 0;
t = null;
gameOver=false;
stop=false;
demo=false;

}

function drawTowers(){
var title=document.getElementById("title");
var tower1=document.getElementById("tower1");
var tower2=document.getElementById("tower2");
var tower3=document.getElementById("tower3");
var settings=document.getElementById("settings");
var titlewidth = parseInt(title.style.width);
var titleheight = parseInt(title.style.height);
var towerwidth = parseInt(tower1.style.width);
var towerheight = parseInt(tower1.style.height);
var settingswidth = parseInt(settings.style.width);
midhoriztower = parseInt(document.getElementById("horiztower1").style.width)/2;
diskheight = parseInt(document.getElementById("disk1").style.height);

title.style.left=offsetleft+(1.5*towerwidth)+offsettower-(titlewidth/2)+"px";
title.style.top=offsettop+"px";
tower1.style.left=offsetleft+"px";
tower1.style.top=offsettop+titleheight+offsethoriz+"px";
tower2.style.left=offsetleft+towerwidth+offsettower+"px";
tower2.style.top=offsettop+titleheight+offsethoriz+"px";
tower3.style.left=offsetleft+(towerwidth+offsettower)*2+"px";
tower3.style.top=offsettop+titleheight+offsethoriz+"px";
settings.style.left=offsetleft+(1.5*towerwidth)+offsettower-(settingswidth/2)+"px";
settings.style.top=parseInt(tower1.style.top)+towerheight+offsethoriz+"px";
}

function drawDisks(disknum){
var tower1=document.getElementById("tower1");
var disktop = parseInt(tower1.style.top)+parseInt(document.getElementById("horiztower1").style.top);
var lefttower1 = parseInt(tower1.style.left);
var disk;
var f=document.hanoi;
basetop = disktop;
for (var i=disk1.length;i>=1;i--){
disk = document.getElementById("disk"+i);
disk.style.zIndex=++zindex;
if (i<=disknum){
disk.style.left=lefttower1+midhoriztower-parseInt(disk.style.width)/2+"px";
disk.style.top=disktop-diskheight-1+"px";
disktop = parseInt(disk.style.top);
diskArray[0][i-1]=disk;
}
else {
disk.style.left="-250px";
disk.style.top="-250px";
diskArray[0][i-1]=null;
}
}
f.minmove.value=f.diskno.options[f.diskno.options.selectedIndex].value;
f.yourmove.value=0;
}

function newGame(obj){
if (movectr>0 && !gameOver && !stop){
if (confirm("Current game will be lost, would you like to continue?")){
initVars();
drawDisks(parseInt(obj.options[obj.options.selectedIndex].text));
}
else document.hanoi.diskno.options.selectedIndex=prevIndex;
}
else {
initVars();
drawDisks(parseInt(obj.options[obj.options.selectedIndex].text));
}
}

function initializeDrag(disk,e){
if (!e) e=event;
if (stop){
alert("You cannot continue solving the puzzle after clicking the 'Solve' button.\nClick 'Restart' button or select Number of disks to continue playing.");
return;
}
indexFr = indexTo;
if (disk.id!=diskArray[indexFr-1][0].id || gameOver || demo) return;
objDisk=disk;
x=e.clientX;
y=e.clientY;
tempx=parseInt(disk.style.left);
tempy=parseInt(disk.style.top);
document.onmousemove=dragDisk;
}

function dragDisk(e){
if (!e) e=event;
zindex++;
drag=true;
var posX = tempx+e.clientX-x;
var posY = tempy+e.clientY-y;
var objTower1 = document.getElementById("tower1");
var objTower2 = document.getElementById("tower2");
var objTower3 = document.getElementById("tower3");
var tower1Left = parseInt(objTower1.style.left);
var tower2Left = parseInt(objTower2.style.left);
var tower3Left = parseInt(objTower3.style.left);
var tower3Width = parseInt(objTower3.style.width);

objDisk.style.zIndex=zindex;
objDisk.style.left=posX+'px';
objDisk.style.top=posY+'px';

if (e.clientX>=document.body.clientWidth-10 || e.clientY>=document.body.clientHeight-5 || e.clientX==5 || e.clientY==5){ //outside available window
indexTo=indexFr;
dropDisk(objDisk);
}
else if ( //in the vicinity of tower 3
(tower3Left<=posX) &&
(tower3Left+tower3Width>=posX) &&
(parseInt(objTower3.style.top)+parseInt(objTower3.style.height)>posY)
){
indexTo=3;
}
else if ((tower2Left<=posX) && (tower2Left+tower3Width>=posX)){ //in the vicinity of tower 2
indexTo=2;
}
else if ((tower1Left<=posX) && (tower1Left+parseInt(objTower1.style.width)>=posX)){ //in the vicinity of tower 1
indexTo=1;
}
else indexTo = indexFr;
return false;
}

function dropDisk(disk){
var f=document.hanoi;
document.onmousemove=new Function("return false");
if (!drag) return;
var gameStatus=false;
var topDisk = diskArray[indexTo-1][0];
if (indexFr==indexTo){
getNewTop(indexFr,null);
pushDisk(disk,indexFr); //put disk back to original tower
getNewTop(indexFr,disk);
}
else if (topDisk==null) {
pushDisk(disk,indexTo);
getNewTop(indexFr,null);
getNewTop(indexTo,disk);
movectr++;
currTower=indexTo;
prevTower=indexFr;

}
else if (parseInt(disk.style.width)<parseInt(topDisk.style.width)){
pushDisk(disk,indexTo);
getNewTop(indexFr,null);
getNewTop(indexTo,disk);
movectr++;
currTower=indexTo;
prevTower=indexFr;
if (indexTo==3) gameStatus=checkStatus();

}
else {
getNewTop(indexFr,null);
pushDisk(disk,indexFr); //put disk back to original tower
getNewTop(indexFr,disk);
}

drag=false;
f.yourmove.value=movectr;
if (gameStatus) {

minmove = parseInt(f.minmove.value);
if (movectr==minmove) msg="\nCongratulations! You solved the puzzle in "+minmove+" moves."
else if (movectr>minmove) msg="\nYou can do better than that."
else msg="";
alert("Game Over !!!"+msg);
gameOver=true;
}
return;
}

function checkStatus(){
var gameStat = false;
var disks=0;
for (var i=0;i<disk3.length;i++){
if (diskArray[2][i]!=null) disks++;
}
if (disks==parseInt(document.hanoi.diskno.options[document.hanoi.diskno.options.selectedIndex].text)) gameStat=true;
return gameStat;
}

function pushDisk(disk,index){
var diskWidth = parseInt(disk.style.width);
var towerLeft = parseInt(document.getElementById("tower"+index).style.left);
var topDisk = diskArray[index-1][0];
if (topDisk!=null){
topDiskWidth = parseInt(topDisk.style.width);
topDiskTop = parseInt(topDisk.style.top);
disk.style.left=towerLeft+midhoriztower-diskWidth/2+"px";
disk.style.top=topDiskTop-diskheight-1+"px";
}
else {
disk.style.left=towerLeft+midhoriztower-diskWidth/2+"px";
disk.style.top=basetop-diskheight-1+"px";
}
}

function getNewTop(index,disk){
if (disk==null){ //pop
for (var i=0;i<disk1.length-1;i++){
diskArray[index-1][i]=diskArray[index-1][i+1];
}
diskArray[index-1][disk1.length-1]=null;
}
else { //push
for (var i=disk1.length-1;i>=1;i--){
diskArray[index-1][i]=diskArray[index-1][i-1];
}
diskArray[index-1][0]=disk;
}
}

function solve(btn){
if (btn.value=="Solve"){
if (movectr>0 && !gameOver && !stop)
if (!confirm("Current game will be aborted, would you like to continue?")) return;
btn.value="Stop";
initVars();
stop=false;
demo=true;
var f=document.hanoi;
f.btnIns.disabled=true;
f.btnRes.disabled=true;

disknum = parseInt(f.diskno.options[f.diskno.options.selectedIndex].text);
drawDisks(disknum);
getMoves(0, 2, 1, disknum);
t=window.setTimeout("moveDisk()",delay);
}
else {
if (t) {
window.clearTimeout(t);
btn.value="Solve";
frm.btnIns.disabled=false;
frm.btnRes.disabled=false;
t = null;
stop=true;
demo=false;
}

}
}

function moveDisk(){
frm = document.hanoi;
disk=diskArray[arrFr[pos]][0];
pushDisk(disk,arrTo[pos]+1);
getNewTop(arrFr[pos]+1,null);
getNewTop(arrTo[pos]+1,disk);
movectr++;
frm.yourmove.value=movectr;
pos++;
if (movectr<parseInt(frm.minmove.value)) t=window.setTimeout("moveDisk()",delay);
else {

gameOver=true;
stop=false;
frm.btnSolve.value="Solve";
frm.btnIns.disabled=false;
frm.btnRes.disabled=false;
}
}

function getMoves(from,to,empty,numDisk){
if (numDisk > 1) {
getMoves(from, empty, to, numDisk - 1);
arrFr[idx] = from;
arrTo[idx++] = to;
getMoves(empty, to, from, numDisk - 1);
}
else {
arrFr[idx] = from;
arrTo[idx++] = to;
}
}





function displayIns(){
var msg="Object of the game is to move all the disks over to Tower 3 (with your mouse).\n";
msg+="But you cannot place a larger disk onto a smaller disk.";

alert(msg);
}