(function(){
    var tbody = document.getElementById('tbody_alluser');
    var frag = document.createDocumentFragment();
    var url= jsGlbalConfig.userApiUrl + "user/GetAllUser";
    var res=null;

    var xhr = new XMLHttpRequest();
    xhr.open('get',url,true);
    xhr.onreadystatechange = function(){
      
    	if(xhr.readyState == 4 && xhr.status ==200){
    	    var	obj= JSON.parse(xhr.responseText);
    		res= obj.Data;

            for(let j=0;j<res.length;j++){
            	var tr = document.createElement("tr");
            	for(key in res[j]){
            		var td = document.createElement("td");
            		td.innerHTML = res[j][key];
            		tr.appendChild(td);
            	}
            	frag.appendChild(tr);
            }

            tbody.appendChild(frag);
    	}
    };

    xhr.send(null);

}())