export default function validateStrongerPassword(password) {
  if (password.length < 8) {
    return 'Password must be at least 8 characters';
  }
  if (password.search(/[a-z]/) < 0) {
    return 'Password must contain at least one lowercase letter';
  }
  if (password.search(/[A-Z]/) < 0) {
    return 'Password must contain at least one uppercase letter';
  }
  if (password.search(/[0-9]/) < 0) {
    return 'Password must contain at least one number';
  }
  if (password.search(/[!@#$%^&*]/) < 0) {
    return 'Password must contain at least one special character';
  }
  return 'ok';
}

export function validateBothPasswords({ password, password2 }) {
  if (password != password2) {
    return 'Passwords do not match';
  } else {
    return validateStrongerPassword(password);
  }
}
