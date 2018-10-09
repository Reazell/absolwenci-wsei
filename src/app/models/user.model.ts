// tslint:disable:max-classes-per-file

export class User {
  Id?: number;
  Name: string;
  Surname: string;
  Email: string;
  constructor(name: string, surname: string, email: string, id?: number) {
    this.Id = id;
    this.Name = name;
    this.Surname = surname;
    this.Email = email;
  }
}

export class RegisteredUser extends User {
  AlbumID: number;
  ProfileName: string;
  Password: string;
}

export class UnregisteredUser extends User {
  Course: string;
  CompletionDate: string;
  DateOfCompletion?: JSON;
  TypeOfStudy: string;
  constructor(
    name: string,
    surname: string,
    email: string,
    course: string,
    completionDate: string,
    typeOfStudy: string,
    id?: number
  ) {
    super(name, surname, email, id);
    this.Course = course;
    this.TypeOfStudy = typeOfStudy;
  }
}
