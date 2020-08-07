export class ErrorCodes {
    code: string;
    message: string;
}

export class ErrorCodeMessage {
    message = 'Error occured! Please contact support';

    public getErrorMessage(error: string) {
        const errorCode = ERROR_CODES.find(e => e.code === error);

        if (!errorCode) {
            return this.message;
        }
        return errorCode.message;
    }
}

export const ERROR_CODES: ErrorCodes[] = [
    {
        code: 'WEATHER_FORECAST_NOT_FOUND',
        message: 'Weather forecast not found!'
    },
    {
        code: 'USER_ALREADY_EXISTS',
        message: 'User already exists!'
    },
    {
        code: 'USER_DOES_NOT_EXIST',
        message: 'User could not be found!'
    },
    {
        code: 'USER_INCORRECT_PASSWORD',
        message: 'You have entered incorrect password!'
    }
];
