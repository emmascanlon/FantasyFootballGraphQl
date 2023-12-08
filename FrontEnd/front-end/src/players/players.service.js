import {nonToastedHttp} from './http';

export const getAllPlayers = (body) => {
    nonToastedHttp.post('/graphql', {params: {body: body}})
}