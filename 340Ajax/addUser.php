<?php
/**
 * Connects to the database.
 * Return false if connection failed.
 * If there was a param sent, I'm sending it back in an XML doc
 */
  include "../../dbInfo.php";

if ($dbLink) {
  if(isset($_GET['who'])){
  	$x=$_GET['who'];
  	$querry="INSERT INTO 340AjaxClass VALUES ('','$x')";
  	$result=mysql_query($querry);
  }
  $querry="SELECT name FROM 340AjaxClass";
  $result=mysql_query($querry);
  if($result) {
    while ($v_row = mysql_fetch_array ($result, MYSQL_ASSOC)) {
      $v_records[] = $v_row;
    }
  }
}
$len=count($v_records);
//build our xml document to return
$return_value = '<?xml version="1.0" standalone="yes"?><info>';
if ($len>0) {  
  for($i=0;$i<count($v_records);$i++){
    $return_value.= '<who>'.$v_records[$i]['name'].'</who>';
  }
}else{
  $return_value.= "<who>No one</who>";
}
$return_value .='</info>';
//echo $return_value;
header("Expires: Mon, 26 Jul 1997 05:00:00 GMT");
header("Last-Modified: " . gmdate("D, d M Y H:i:s") . " GMT");
header("Cache-Control: no-store, no-cache, must-revalidate");
header("Cache-Control: post-check=0, pre-check=0", false);
header("Pragma: no-cache");
header('Content-Type: text/xml'); 
echo $return_value; // This will become the response value for the XMLHttpRequest object
?>