import { Photo } from './photo';

export interface Resources {
  id: number;
  rm_First_Name?: string;
  rm_Middle_Name?: string;
  rm_Last_Name?: string;
  rm_Login_Id: string;
  rm_Email: string;
  rm_Role_Id?: string;
  rm_Gender: number;
  age: number;
  rm_address?: string;
  rm_Contactno?: string;
  rm_City?: string;
  rm_Country?: string;
  rm_Postalcode?: string;
  rm_KnownAS?: string;
  rm_LastActive?: Date;
  rm_Introduction?: string;
  lookingFor?: string;
  interests?: string;
  photoUrl: string;
  photos?: Photo[];
  craated_by: string;
  craated_on: Date;
  modified_by: string;
  modified_on: Date;
  rm_Active?: number;
}
