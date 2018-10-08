// tslint:disable:max-classes-per-file

export class User {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  profileName: string;
  phoneNum: string;
  // constructor(
  //   firstName: string,
  //   lastName: string,
  //   email: string,
  //   password: string,
  //   profileName: string
  // ) {
  //   this.firstName = firstName;
  //   this.lastName = lastName;
  //   this.email = email;
  //   this.password = password;
  //   this.profileName = profileName;
  // }
}
export class Graduate extends User {}
export class Student extends User {
  albumID: string;
}
export class Employer extends User {
  companyName: string;
  location: string;
  companyDescription: string;
}
