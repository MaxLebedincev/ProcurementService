import axios from "axios";
import {ref} from 'vue';

export async function UseRegistration(login :string, password :string, email :string, role :string) {
    const userinfo = ref({})
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post(
                '/Account/Register',
                {
                    login: login,
                    password: password,
                    email: email,
                    role: role
                });
            userinfo.value = response.data.error ?? response.data.success;
            // answer.value = userinfo.value.error ? false: true;
            answer.value = true;
        } catch (e) {
            answer.value = false;
        }
    }
    await fetching();
    return {
        userinfo, answer
    }
}