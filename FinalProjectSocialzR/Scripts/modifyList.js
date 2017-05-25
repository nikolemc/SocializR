var removeClassElements = document.getElementsByClassName('remove');

for(var i = 0; i < removeClassElements.length; i++){
  var element = removeClassElements[i];  
  element.addEventListener('click', remove);
}

var editClassElements = document.getElementsByClassName('edit');

for(var i = 0; i < editClassElements.length; i++){
  var element = editClassElements[i];  
  element.addEventListener('click', edit);
}

function remove() {
  var li = this.parentNode;
  var ul = li.parentNode;  
  ul.removeChild(li);
}

function edit() {
  var li = this.parentNode;
  var span = li.children[0];
  span.setAttribute('contenteditable', true);
  span.focus();
}