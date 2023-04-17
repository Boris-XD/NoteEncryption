export function validateEmail(valor) {
  let emails = valor.split(',');
  let re = /^([\da-z_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;
  let response = true;
  for (const email of emails) {
    if (!re.exec(email)) {
      return false;
    }
  }
  return response;
}
export function validateDate(date) {
  if (date == '') {
    return false;
  }
  return true;
}

export function ValidateContainerName(name){
  if(name == 'Root')
  {
    return false;
  }
  return true;
}
